import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleRefCapabilityMapper from '../vehicleRefCapability/vehicleRefCapabilityMapper';
import VehicleRefCapabilityViewModel from '../vehicleRefCapability/vehicleRefCapabilityViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface VehicleRefCapabilityTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface VehicleRefCapabilityTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<VehicleRefCapabilityViewModel>;
}

export class  VehicleRefCapabilityTableComponent extends React.Component<
VehicleRefCapabilityTableComponentProps,
VehicleRefCapabilityTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: VehicleRefCapabilityViewModel) {
  this.props.history.push(ClientRoutes.VehicleRefCapabilities + '/edit/' + row.id);
}

handleDetailClick(e:any, row: VehicleRefCapabilityViewModel) {
  this.props.history.push(ClientRoutes.VehicleRefCapabilities + '/' + row.id);
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
          let response = resp.data as Array<Api.VehicleRefCapabilityClientResponseModel>;

          console.log(response);

          let mapper = new VehicleRefCapabilityMapper();
          
          let vehicleRefCapabilities:Array<VehicleRefCapabilityViewModel> = [];

          response.forEach(x =>
          {
              vehicleRefCapabilities.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: vehicleRefCapabilities,
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
                    Header: 'VehicleRefCapabilities',
                    columns: [
					  {
                      Header: 'VehicleCapabilityId',
                      accessor: 'vehicleCapabilityId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.VehicleCapabilities + '/' + props.original.vehicleCapabilityId); }}>
                          {String(
                            props.original.vehicleCapabilityIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'VehicleId',
                      accessor: 'vehicleId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Vehicles + '/' + props.original.vehicleId); }}>
                          {String(
                            props.original.vehicleIdNavigation.toDisplay()
                          )}
                        </a>
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
                              row.original as VehicleRefCapabilityViewModel
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
                              row.original as VehicleRefCapabilityViewModel
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
    <Hash>dd356640b71eff1c97511f7cd5cdac2c</Hash>
</Codenesium>*/