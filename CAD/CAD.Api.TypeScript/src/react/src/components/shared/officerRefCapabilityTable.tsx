import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OfficerRefCapabilityMapper from '../officerRefCapability/officerRefCapabilityMapper';
import OfficerRefCapabilityViewModel from '../officerRefCapability/officerRefCapabilityViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface OfficerRefCapabilityTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface OfficerRefCapabilityTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<OfficerRefCapabilityViewModel>;
}

export class  OfficerRefCapabilityTableComponent extends React.Component<
OfficerRefCapabilityTableComponentProps,
OfficerRefCapabilityTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: OfficerRefCapabilityViewModel) {
  this.props.history.push(ClientRoutes.OfficerRefCapabilities + '/edit/' + row.id);
}

handleDetailClick(e:any, row: OfficerRefCapabilityViewModel) {
  this.props.history.push(ClientRoutes.OfficerRefCapabilities + '/' + row.id);
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
          let response = resp.data as Array<Api.OfficerRefCapabilityClientResponseModel>;

          console.log(response);

          let mapper = new OfficerRefCapabilityMapper();
          
          let officerRefCapabilities:Array<OfficerRefCapabilityViewModel> = [];

          response.forEach(x =>
          {
              officerRefCapabilities.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: officerRefCapabilities,
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
                    Header: 'OfficerRefCapabilities',
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
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as OfficerRefCapabilityViewModel
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
                              row.original as OfficerRefCapabilityViewModel
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
    <Hash>3734a871f56df659f13a433e2143d595</Hash>
</Codenesium>*/