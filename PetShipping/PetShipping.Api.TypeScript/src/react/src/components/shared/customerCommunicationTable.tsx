import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CustomerCommunicationMapper from '../customerCommunication/customerCommunicationMapper';
import CustomerCommunicationViewModel from '../customerCommunication/customerCommunicationViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface CustomerCommunicationTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface CustomerCommunicationTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<CustomerCommunicationViewModel>;
}

export class  CustomerCommunicationTableComponent extends React.Component<
CustomerCommunicationTableComponentProps,
CustomerCommunicationTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: CustomerCommunicationViewModel) {
  this.props.history.push(ClientRoutes.CustomerCommunications + '/edit/' + row.id);
}

handleDetailClick(e:any, row: CustomerCommunicationViewModel) {
  this.props.history.push(ClientRoutes.CustomerCommunications + '/' + row.id);
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
          let response = resp.data as Array<Api.CustomerCommunicationClientResponseModel>;

          console.log(response);

          let mapper = new CustomerCommunicationMapper();
          
          let customerCommunications:Array<CustomerCommunicationViewModel> = [];

          response.forEach(x =>
          {
              customerCommunications.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: customerCommunications,
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
                    Header: 'CustomerCommunications',
                    columns: [
					  {
                      Header: 'CustomerId',
                      accessor: 'customerId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Customers + '/' + props.original.customerId); }}>
                          {String(
                            props.original.customerIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'DateCreated',
                      accessor: 'dateCreated',
                      Cell: (props) => {
                      return <span>{String(props.original.dateCreated)}</span>;
                      }           
                    },  {
                      Header: 'EmployeeId',
                      accessor: 'employeeId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Employees + '/' + props.original.employeeId); }}>
                          {String(
                            props.original.employeeIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Id',
                      accessor: 'id',
                      Cell: (props) => {
                      return <span>{String(props.original.id)}</span>;
                      }           
                    },  {
                      Header: 'Notes',
                      accessor: 'note',
                      Cell: (props) => {
                      return <span>{String(props.original.note)}</span>;
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
                              row.original as CustomerCommunicationViewModel
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
                              row.original as CustomerCommunicationViewModel
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
    <Hash>2a61743f7773b761653d758959673777</Hash>
</Codenesium>*/