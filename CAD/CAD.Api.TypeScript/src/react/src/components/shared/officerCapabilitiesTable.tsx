import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OfficerCapabilitiesMapper from '../officerCapabilities/officerCapabilitiesMapper';
import OfficerCapabilitiesViewModel from '../officerCapabilities/officerCapabilitiesViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface OfficerCapabilitiesTableComponentProps {
  capabilityId:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface OfficerCapabilitiesTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<OfficerCapabilitiesViewModel>;
}

export class  OfficerCapabilitiesTableComponent extends React.Component<
OfficerCapabilitiesTableComponentProps,
OfficerCapabilitiesTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: OfficerCapabilitiesViewModel) {
  this.props.history.push(ClientRoutes.OfficerCapabilities + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: OfficerCapabilitiesViewModel) {
   this.props.history.push(ClientRoutes.OfficerCapabilities + '/' + row.id);
 }

  componentDidMount() {
	this.loadRecords();
  }

  loadRecords() {
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
          let response = resp.data as Array<Api.OfficerCapabilitiesClientResponseModel>;

          console.log(response);

          let mapper = new OfficerCapabilitiesMapper();
          
          let officerCapabilities:Array<OfficerCapabilitiesViewModel> = [];

          response.forEach(x =>
          {
              officerCapabilities.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: officerCapabilities,
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
                    Header: 'OfficerCapabilities',
                    columns: [
					  {
                      Header: 'CapabilityId',
                      accessor: 'capabilityId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.OfficerCapabilities + '/' + props.original.capabilityId); }}>
                          {String(
                            props.original.capabilityIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'OfficerId',
                      accessor: 'officerId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Officers + '/' + props.original.officerId); }}>
                          {String(
                            props.original.officerIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },
                    {
                        Header: 'Actions',
					    minWidth:150,
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as OfficerCapabilitiesViewModel
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
                              row.original as OfficerCapabilitiesViewModel
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
    <Hash>58bb379a28d08b988e4795fddada37f4</Hash>
</Codenesium>*/