import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CreditCardMapper from '../creditCard/creditCardMapper';
import CreditCardViewModel from '../creditCard/creditCardViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface CreditCardTableComponentProps {
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
    this.props.history.push(
      ClientRoutes.CreditCards + '/edit/' + row.creditCardID
    );
  }

  handleDetailClick(e: any, row: CreditCardViewModel) {
    this.props.history.push(ClientRoutes.CreditCards + '/' + row.creditCardID);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.CreditCardClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CreditCardMapper();

        let creditCards: Array<CreditCardViewModel> = [];

        response.data.forEach(x => {
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
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
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
                    Header: 'Card Number',
                    accessor: 'cardNumber',
                    Cell: props => {
                      return <span>{String(props.original.cardNumber)}</span>;
                    },
                  },
                  {
                    Header: 'Card Type',
                    accessor: 'cardType',
                    Cell: props => {
                      return <span>{String(props.original.cardType)}</span>;
                    },
                  },
                  {
                    Header: 'Exp Month',
                    accessor: 'expMonth',
                    Cell: props => {
                      return <span>{String(props.original.expMonth)}</span>;
                    },
                  },
                  {
                    Header: 'Exp Year',
                    accessor: 'expYear',
                    Cell: props => {
                      return <span>{String(props.original.expYear)}</span>;
                    },
                  },
                  {
                    Header: 'Modified Date',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
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
    <Hash>5f5e1a2919ee92d2c8df3db0dc75652e</Hash>
</Codenesium>*/