import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CountryRequirementMapper from '../countryRequirement/countryRequirementMapper';
import CountryRequirementViewModel from '../countryRequirement/countryRequirementViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface CountryRequirementTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface CountryRequirementTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<CountryRequirementViewModel>;
}

export class  CountryRequirementTableComponent extends React.Component<
CountryRequirementTableComponentProps,
CountryRequirementTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: CountryRequirementViewModel) {
  this.props.history.push(ClientRoutes.CountryRequirements + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: CountryRequirementViewModel) {
   this.props.history.push(ClientRoutes.CountryRequirements + '/' + row.id);
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
          let response = resp.data as Array<Api.CountryRequirementClientResponseModel>;

          console.log(response);

          let mapper = new CountryRequirementMapper();
          
          let countryRequirements:Array<CountryRequirementViewModel> = [];

          response.forEach(x =>
          {
              countryRequirements.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: countryRequirements,
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
                    Header: 'CountryRequirements',
                    columns: [
					  {
                      Header: 'CountryId',
                      accessor: 'countryId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Countries + '/' + props.original.countryId); }}>
                          {String(
                            props.original.countryIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Details',
                      accessor: 'detail',
                      Cell: (props) => {
                      return <span>{String(props.original.detail)}</span>;
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
                              row.original as CountryRequirementViewModel
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
                              row.original as CountryRequirementViewModel
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
    <Hash>f4b562e67463c4b9c72dbcb5567b6c38</Hash>
</Codenesium>*/