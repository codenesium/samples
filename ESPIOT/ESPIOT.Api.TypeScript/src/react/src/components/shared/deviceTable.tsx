import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DeviceMapper from '../device/deviceMapper';
import DeviceViewModel from '../device/deviceViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface DeviceTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface DeviceTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<DeviceViewModel>;
}

export class  DeviceTableComponent extends React.Component<
DeviceTableComponentProps,
DeviceTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: DeviceViewModel) {
  this.props.history.push(ClientRoutes.Devices + '/edit/' + row.id);
}

handleDetailClick(e:any, row: DeviceViewModel) {
  this.props.history.push(ClientRoutes.Devices + '/' + row.id);
}

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.DeviceClientResponseModel>;

          console.log(response);

          let mapper = new DeviceMapper();
          
          let devices:Array<DeviceViewModel> = [];

          response.forEach(x =>
          {
              devices.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: devices,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
	let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
       return <Spin size="large" />;
    }
	else if (this.state.errorOccurred) {
	  return <Alert message={this.state.errorMessage} type='error' />;
	}
	 else if (this.state.loaded) {
      return (
	  <div>
		{message}
         <ReactTable 
                data={this.state.filteredRecords}
				defaultPageSize={10}
                columns={[{
                    Header: 'Devices',
                    columns: [
					  {
                      Header: 'Date of Last Ping',
                      accessor: 'dateOfLastPing',
                      Cell: (props) => {
                      return <span>{String(props.original.dateOfLastPing)}</span>;
                      }           
                    },  {
                      Header: 'Active',
                      accessor: 'isActive',
                      Cell: (props) => {
                      return <span>{String(props.original.isActive)}</span>;
                      }           
                    },  {
                      Header: 'Name',
                      accessor: 'name',
                      Cell: (props) => {
                      return <span>{String(props.original.name)}</span>;
                      }           
                    },  {
                      Header: 'Public Id',
                      accessor: 'publicId',
                      Cell: (props) => {
                      return <span>{String(props.original.publicId)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as DeviceViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleEditClick(
                              e,
                              row.original as DeviceViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        </div>)
                    }],
                    
                  }]} />
			</div>
      );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>606649aa03981f4978dc01c379ed00e2</Hash>
</Codenesium>*/