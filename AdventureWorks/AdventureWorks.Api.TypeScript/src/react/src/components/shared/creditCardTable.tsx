import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CreditCardMapper from '../creditCard/creditCardMapper';
import CreditCardViewModel from '../creditCard/creditCardViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface CreditCardTableComponentProps {
  creditCardID: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface CreditCardTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<CreditCardViewModel>;
}

export class CreditCardTableComponent extends React.Component<
  CreditCardTableComponentProps,
  CreditCardTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: CreditCardViewModel) {
    this.props.history.push(ClientRoutes.CreditCards + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: CreditCardViewModel) {
    this.props.history.push(ClientRoutes.CreditCards + '/' + row.id);
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.CreditCardClientResponseModel>;

          console.log(response);

          let mapper = new CreditCardMapper();

          let creditCards: Array<CreditCardViewModel> = [];

          response.forEach(x => {
            creditCards.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: creditCards,
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
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <div>
          {message}
          <ReactTable
            data={this.state.filteredRecords}
            defaultPageSize={10}
            columns={[
              {
                Header: 'CreditCards',
                columns: [
                  {
                    Header: 'CardNumber',
                    accessor: 'cardNumber',
                    Cell: props => {
                      return <span>{String(props.original.cardNumber)}</span>;
                    },
                  },
                  {
                    Header: 'CardType',
                    accessor: 'cardType',
                    Cell: props => {
                      return <span>{String(props.original.cardType)}</span>;
                    },
                  },
                  {
                    Header: 'CreditCardID',
                    accessor: 'creditCardID',
                    Cell: props => {
                      return <span>{String(props.original.creditCardID)}</span>;
                    },
                  },
                  {
                    Header: 'ExpMonth',
                    accessor: 'expMonth',
                    Cell: props => {
                      return <span>{String(props.original.expMonth)}</span>;
                    },
                  },
                  {
                    Header: 'ExpYear',
                    accessor: 'expYear',
                    Cell: props => {
                      return <span>{String(props.original.expYear)}</span>;
                    },
                  },
                  {
                    Header: 'ModifiedDate',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Actions',
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as CreditCardViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as CreditCardViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>86da4342cbfee84b57b2fa843e9537eb</Hash>
</Codenesium>*/